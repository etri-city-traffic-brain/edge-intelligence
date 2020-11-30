# conda activate detect
# command : python app_modify_fin.py --video_folder="videodata/200200130_2.mp4" --news="news" --diff_path="videodata/20200130_9.mp4" --news2="ne"
import cv2
#from PyQt5.QtWidgets import QApplication, QMainWindow, QFileDialog
#from PyQt5.QtGui import QImage, QPixmap
#from gui import *
import copy
from counter import CounterThread
from utils.sort import *
from models import *
from utils.utils import *
from utils.datasets import *
from config import *

import argparse
import predict
from torch.utils.data import DataLoader
import predict

import glob
import pandas as pd
import csv


def cal_iou(box1,box2):
    x1 = max(box1[0],box2[0])
    y1 = max(box1[1],box2[1])
    x2 = min(box1[2],box2[2])
    y2 = min(box1[3],box2[3])
    i = max(0,(x2-x1))*max(0,(y2-y1))
    u = (box1[2]-box1[0])*(box1[3]-box1[1]) + (box2[2]-box2[0])*(box2[3]-box2[1]) -  i
    iou = float(i)/float(u)
    return iou

def get_objName(item,objects):
    iou_list = []
    for i,object in enumerate(objects):
        x, y, w, h = object[2]
        x1, y1, x2, y2 = int(x - w / 2), int(y - h / 2), int(x + w / 2), int(y + h / 2)
        iou_list.append(cal_iou(item[:4],[x1,y1,x2,y2]))
    max_index = iou_list.index(max(iou_list))
    return objects[max_index][0]

def filter_out_repeat(objects):
    objects = sorted(objects,key=lambda x: x[1])
    l = len(objects)
    new_objects = []
    if l > 1:
        for i in range(l-1):
            flag = 0
            for j in range(i+1,l):
                x_i, y_i, w_i, h_i = objects[i][2]
                x_j, y_j, w_j, h_j = objects[j][2]
                box1 = [int(x_i - w_i / 2), int(y_i - h_i / 2), int(x_i + w_i / 2), int(y_i + h_i / 2)]
                box2 = [int(x_j - w_j / 2), int(y_j - h_j / 2), int(x_j + w_j / 2), int(y_j + h_j / 2)]
                if cal_iou(box1,box2) >= 0.7:
                    flag = 1
                    break
            #if no repeat
            if not flag:
                new_objects.append(objects[i])
        #add the last one
        new_objects.append(objects[-1])
    else:
        return objects

    return list(tuple(new_objects))

def update_counter_results(counter_results,vid_name):
    with open("results/results_"+vid_name[:-4].split('/')[-1]+".txt", "a") as f:
        #f.writelines(' '.join(map(lambda x: str(x),counter_results)))
        #f.write("\n")
        
        
        for i, result in enumerate(counter_results):
            #print("i:{} results:{}\n".format(i,result))

            print("result: {}\n".format(result))
            f.writelines(' '.join(map(lambda x: str(x),result)))
            #f.wirte(result)
            f.write("\n")

def update_counter_results_gubun(cnt,vid_name):
    print(vid_name[:-4])
    with open("results/results_"+vid_name[:-4].split('/')[-1]+".txt", "a") as f:
        f.write(str(fcnt))
        f.write(" frame changed\n\n")

header_num = 0
def make_df(arr,vid_name):
    global header_num
    with open("results/results_"+vid_name[:-4].split('/')[-1]+".csv","a",newline='') as f:
        writer = csv.writer(f)
        if header_num == 0 :
            columns = ["frame_num","id","d2x","d2y","rx","ry","heading"]
            writer.writerow(columns)
        for result in arr:
            result.insert(0,header_num)
            writer.writerow(result)
        header_num += 1


def counter(permission,colorDict,frame,mot_tracker,videoName,viul):
    global history
    global model
    global device
    
    videoName = videoName.split('/')[-1]

    class_names = ['bicycle','bus','car','motorbike','truck']
    objects = predict.yolo_prediction(model,device,frame,class_names)
    objects = filter(lambda x : x[0] in permission, objects)
    objects = filter(lambda x : x[1] > 0.5, objects)

    objects = filter_out_repeat(objects)
    #print("counter_ob : {}".format(objects))
    detections = []
    for item in objects:
        detections.append([int(item[2][0] - item[2][2] / 2),
                           int(item[2][1] - item[2][3] / 2),
                           int(item[2][0] + item[2][2] / 2),
                           int(item[2][1] + item[2][3] / 2),
                           item[1]])
    track_bbs_ids = mot_tracker.update(np.array(detections))

    if len(track_bbs_ids) > 0:
        for bb in track_bbs_ids:
            id = int(bb[-1])
            objectName = get_objName(bb,objects) 
            if id not in history.keys():
                history[id] = {}
                history[id]["no_update_count"] = 0
                history[id]["his"] = [] 
                history[id]["his"].append(objectName)
            else:
                history[id]["no_update_count"] = 0
                history[id]["his"].append(objectName)

    df_input = []
    
    for i, item in enumerate(track_bbs_ids):
        bb = list(map(lambda x: int(x), item))
        #print("bb :{}".format(bb))
        id = bb[-1]
        x1, y1, x2, y2 = bb[:4]

        his = history[id]["his"]
        result = {}
        for i in set(his):
            result[i] = his.count(i)
        res = sorted(result.items(), key=lambda d: d[1], reverse=True)
        objectName = res[0][0]

        boxColor = colorDict[objectName]
        cv2.rectangle(frame, (x1, y1), (x2, y2), boxColor, thickness=2)
        cx = (x2+x1)/2
        cy = (y2+y1)/2
        rx = cx * viul
        ry = cy * viul

        print("points\nid:{}, obj:{}, x:{}, y:{}, rx:{}, ry:{}".format(str(id),objectName,cx,cy,rx,ry))
        save = []
        save.append([id,objectName,[cx,cy]])
        update_counter_results(save,videoName)
        cv2.putText(frame, str(id) + "_" + objectName, (x1 - 1, y1 - 3), cv2.FONT_HERSHEY_COMPLEX, 0.7,
                    boxColor,
                    thickness=2) 
        v_id = "V"+str(id)
        df_input.append([v_id,cx,cy,rx,ry,''])
    make_df(df_input,videoName)



    counter_results = []
    #videoName = videoName.split('/')[-1]
    #removed_id_list = []

    for id in history.keys():    #extract id after tracking
        history[id]["no_update_count"] += 1
        if  history[id]["no_update_count"] > 5:
            his = history[id]["his"]
            result = {}
            for i in set(his):
                result[i] = his.count(i)
            res = sorted(result.items(), key=lambda d: d[1], reverse=True)
            objectName = res[0][0]
            #japyo = history[id]["point"]
            counter_results.append([videoName,id,objectName])
            #print(history)
            #print("check\nid={},obj={},x:{},y:{}".format(id,objectName,
            #del id
            #removed_id_list.append(id)

    #for id in removed_id_list:
    #    _ = history.pop(id)

    # print(self.history)
    #update_counter_results(counter_results)


    return frame

def cal_heading(df_path,direction):
    df = pd.read_csv(df_path)
    vid_list = []
    # vehicle id 갖고와
    for i in range(len(df)):
        vid = df["id"].loc[i]
        vid_list.append(vid)
    #중복 제거
    my_set = set()
    global clean_vid_list
    clean_vid_list = []
    for e in vid_list:
        if e not in my_set:
            clean_vid_list.append(e)
            my_set.add(e)

    #print(clean_vid_list)
    
    for idd in clean_vid_list:
        df_id = df[df["id"]==idd]
        tmp=0
        while True:
            vfx,vfy = int(df_id["d2x"].iloc[tmp]),int(df_id["d2y"].iloc[tmp])
            #print(vfx,vfy)
            #NS
            if len(direction)==2:
                nx,ny = point_list[2][0],point_list[2][1]
                sx,sy = point_list[3][0],point_list[3][1]
                if vfx > nx and vfx < sx:
                    heading = "S"
                else:
                    heading = "N"

            elif len(direction)==4:
                nx,ny = point_list[2][0],point_list[2][1]
                ex,ey = point_list[3][0],point_list[3][1]
                wx,wy = point_list[4][0],point_list[4][1]
                sx,sy = point_list[5][0],point_list[5][1]
                if vfx<wx and vfy<=wy:
                    heading = "W"
                elif vfx>ex and vfy>ey:
                    heading = "E"
                elif vfx>nx and vfy<ny:
                    heading = "N"
                elif vfx<sx and vfy>sy:
                    heading = "S" 
                else:
                    heading = ''  
            #print(heading)                                                    
            df_id.iloc[tmp, df.columns.get_loc('heading')]= heading
            tmp += 1
            if tmp==len(df_id):
                df[df["id"]==idd] = df_id
                break

          
    return df

point_list = []
init_frame_cnt = 0

def open_video(openfile_name):
    videoList = [openfile_name]
    vid = cv2.VideoCapture(videoList[0])
    cnt = 0
    while vid.isOpened():
        ret,frame = vid.read()
        cnt+=1
        if cnt==1:
            cv2.imwrite('videodata/sampleImage.jpg',frame)

        vid.release()   

def mouse_callback(event, x, y, flags, param):
    global point_list, count, img_original


    # click
    if event == cv2.EVENT_LBUTTONDOWN:
        #print("(%d, %d)" % (x, y))
        point_list.append((x, y))

        #print(point_list)
        cv2.circle(img_original, (x, y), 3, (0, 0, 255), -1)

def make_flow(df_path):
    df = pd.read_csv(df_path)
    df = df.dropna().reset_index(drop=True)
    df_1m = df[(df["frame_num"]>=0) & (df["frame_num"]<60)]
    df_2m = df[(df["frame_num"]>=60) & (df["frame_num"]<120)]
    df_3m = df[(df["frame_num"]>=120) & (df["frame_num"]<180)]
    df_4m = df[(df["frame_num"]>=180) & (df["frame_num"]<240)]
    df_5m = df[(df["frame_num"]>=240) & (df["frame_num"]<300)]
    df_list = [df_1m,df_2m,df_3m,df_4m,df_5m]
    flow_df = pd.DataFrame(columns=["time","news",'n_v count','e_v count','w_v count','s_v count','n_avg speed','e_avg speed','w_avg speed','s_avg speed'])
        #두개 한꺼번에
    time_cnt = 0
    idx=0
    for dl in df_list:
        idx+=1
        time_cnt += 1
        h_list = []
        n,e,w,s = 0,0,0,0
        df_sub1 = dl.drop_duplicates(["id"],keep="last") #아이디 중복 제거 마지막 프레임만 남겨
        for i in range(len(df_sub1)):
            if df_sub1["heading"].iloc[i] == "N":
                n+=1
            if df_sub1["heading"].iloc[i] == "E":
                e+=1
            if df_sub1["heading"].iloc[i] == "W":
                w+=1
            else:
                s+=1
        h_list.append(n);h_list.append(e);h_list.append(w);h_list.append(s);
        main_heading = h_list.index(max(h_list))
        if main_heading==0:
            main_heading="N"
        if main_heading==1:
            main_heading="E"
        if main_heading==2:
            main_heading="W"
        else:
            main_heading="S"        
        #print(h_list, main_heading)
        #output = [time_cnt,main_heading,7,7,7,7, h_list[0],h_list[1],h_list[2],h_list[3]]
        #flow_df.loc[idx] = output

    #for dl in df_list:
        clean_v_list=[]
        #cnt_flow+=1
        # count 구하기
        v_list = []
        news_sum = 0
        for i in range(len(dl)):
            v_id = dl["id"].iloc[i]
            v_list.append(v_id) 
        #print(v_list)
        v_set = set()
        for e in v_list:
            if e not in v_set:
                clean_v_list.append(e)
                v_set.add(e)
        #print(clean_v_list)    
        # heading 별 속도
        speed_list = []
        for _dir in ["N","E","W","S"]:
            speed = 0
            for _id in clean_v_list:
                df_sub2 = dl[(dl["heading"]==_dir) & (dl["id"]==_id)]
                if len(df_sub2)<=1:
                    pass
                else:
                    point1x,point1y = df_sub2["rx"].iloc[0],df_sub2["ry"].iloc[0]
                    point2x,point2y = df_sub2["rx"].iloc[-1],df_sub2["ry"].iloc[-1]
                    time = df_sub2["frame_num"].iloc[-1] - df_sub2["frame_num"].iloc[0]
                    distance = abs(math.sqrt(math.pow(point2x-point1x,2)+math.pow(point2y-point2x,2)))/100
                    speed += distance/time
            #print(speed)
            speed_list.append(speed)
            
        output = [time_cnt,main_heading, h_list[0],h_list[1],h_list[2],h_list[3],speed_list[0],speed_list[1],speed_list[2],speed_list[3]]
        flow_df.loc[idx] = output
        #idx +=1

    return flow_df

def framediff(current_frame_gray,previous_frame_gray):
    global check_diff
    check_diff=0
    frame_diff = cv2.absdiff(current_frame_gray,previous_frame_gray)
    cv2.imshow('frame diff ',frame_diff)
    #n_diff = np.mean(frame_diff,axis=2)
    #therhold = 20
    #n_diff[n_diff<=20]=0
    #n_diff[n_diff>therhold]=255
    #mask = np.dstack([n_diff]*3)
    #print(np.sum(mask))
    diff = np.mean(frame_diff)
    if diff>50:
        check_diff=1
    return frame_diff

        
            
if __name__ =="__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("--video_folder",type=str)
    parser.add_argument("--diff_path",type=str)
    parser.add_argument("--model_def",type=str,default="config/yolov3.cfg")
    parser.add_argument("--weights_path",type=str, default="weights/yolov3.weights")
    parser.add_argument("--data_config",type=str, default="config/coco.data")
    parser.add_argument("--img_size",type=int,default=416)
    parser.add_argument("--n_cpu", type=int, default=0, help="number of cpu threads to use during batch generation")
    parser.add_argument("--batch_size", type=int, default=1, help="size of the batches")
    parser.add_argument("-o",type=str)
    parser.add_argument("--news",type=str)
    parser.add_argument("--news2",type=str)
    #parser.add_argument("--area",type=str)
    opt = parser.parse_args()
    
    #print("ok {} {}\n".format(opt.area,opt.video_folder))
    #print("list -> {}".format(type(opt.area)))
    

    
    #model_def = opt.model_def
    #weight_path = opt.weight_path
    #video_folder = opt.video_folder
    data_config = opt.data_config
    news_config = opt.news
    news_config2 = opt.news2
    news_arr = [news_config,news_config2]
    data_config = parse_data_config(data_config)
    yolo_calss_names = load_classes(data_config["names"])
    #print(yolo_calss_names)

    device =  torch.device("cuda" if torch.cuda.is_available() else "cpu")
    print("current device = {}".format(device))

    print("Loading model...")
    model = Darknet(opt.model_def).to(device)
    if opt.weights_path.endswith(".weights"):
        model.load_darknet_weights(opt.weights_path)
    else:
        model.load_state_dict(torch.load(opt.weights_path))

    model.eval()


   
    #counterThread = CounterThread(model,yolo_calss_names,device)
    #counterThread.sin_counterResult.connect(show_image_label)

    openfile_name = opt.video_folder
    diff_name = opt.diff_path
    videoList = [openfile_name,diff_name]
    #videoList2= [diff_name]

    ## using glob 
    #videoList = glob.glob(videoList[0]+"*.mp4")
    #print(videoList)

    for k,my_path in enumerate(videoList):

        save_dir = "results"
        if not os.path.exists(save_dir): os.makedirs(save_dir)

        permission = names
        colorDict = color_dict
        history = {}
        mot_tracker = Sort(max_age=10, min_hits=2)
        vid_path = my_path[:-4].split('/')[-1]
        open_video(my_path)
        cv2.namedWindow('original')
        cv2.setMouseCallback('original', mouse_callback)


        img_original = cv2.imread("reference.jpg")


        #print(img_original[:2])
        while(True):
            cv2.imshow("original", img_original)


            height, width = img_original.shape[:2]
            #print(point_list)
            #x2,y2 = point_list[1]
            #x1,y1 = point_list[2]
            #width,height  = x2-x1,y2-y1

            if cv2.waitKey(1)&0xFF == 32: # space bar -> loop exit
                break
        #print(point_list)

        # 차선 길이 
        x0,y0 = point_list[0][0],point_list[0][1]
        x1,y1 = point_list[1][0],point_list[1][1]
        # heading
        print("pointlist###################")
        print(point_list)

        #px1 = 0.026
        #height*px1 : length = rw : 2000
        #height : real = length : 800
        length = (math.sqrt(math.pow(x1-x0,2)+math.pow(y1-y0,2)))
        #rh = int((800 * height * px1)/(length*px1))
        rh = height*2000/length
        print("video height : {}".format(height))
        print("chasun len : {}".format(length))
        print("real height: {}".format(rh))
        viul = int(rh/height)  #차선 길이 20m

        #img_result = cv2.warpPerspective(img_original, M, (width2*viul ,height2*viul)) ##비율 문제


        #cv2.imshow("result1", img_result)
        #cv2.waitKey(0)
        cv2.destroyAllWindows() 
    
    #for video in videoList:
        last_max_id = 0
        cap = cv2.VideoCapture(my_path)
        #out =  cv2.VideoWriter(os.path.join(save_dir,video.split("/")[-1]), cv2.VideoWriter_fourcc('X', 'V', 'I', 'D'), 10, (1920, 1080))
        frame_count = 0
        fcnt = 0
        while cap.isOpened():
            ret, frame = cap.read()
            if ret:
                if frame_count % 30 ==0:
                    print("frame_count : {}\n".format(frame_count))
                    a1 = time.time()
                    frame = counter(permission, colorDict, frame, mot_tracker, my_path,viul)
                    #out.write(frame)
                    a2 = time.time()
                    print(f"fps: {1 / (a2 - a1):.2f}")
                frame_count += 1

                if frame_count % 30 ==1:
                    update_counter_results_gubun(fcnt,my_path)
                    fcnt +=1

            else:
                break

        KalmanBoxTracker.count = 0
        cap.release()
        #out.release()
        print("detect A finish\n Start cal_heading...")

    
        final_df = cal_heading("results/results_"+vid_path+".csv",news_arr[k])
    
        final_df.to_csv("results/f_results_"+vid_path+".csv",index=False)
        #final_df2 = cal_outlier("results/f_results.csv")
        #mp4_kind = openfile_name[10:-4]
        #final_df.to_csv("results/results_"+mp4_kind+".csv",index=False)
        #print(clean_vid_list)
        #print("cal heading finish\n Start Making flow...")
        print("cal heading finish")
        _flow_df = make_flow("results/f_results_"+vid_path+".csv")
        _flow_df.to_csv("results/flow_"+vid_path+".csv",index=False)
        header_num=0
    print("Flow finish\nCompare start")

    
    print("Compare...")
    print(videoList)
    cap_d1 = cv2.VideoCapture(videoList[0])
    cap_d2 = cv2.VideoCapture(videoList[1])
    fgbg =  cv2.createBackgroundSubtractorMOG2()  
    while(cap_d1.isOpened()):
        ret_d1,b_frame = cap_d1.read()
        ret_d2,a_frame = cap_d2.read()
        if fcnt %30==0:
            b_frame_gray = cv2.cvtColor(b_frame, cv2.COLOR_BGR2GRAY)
            a_frame_gray = cv2.cvtColor(a_frame, cv2.COLOR_BGR2GRAY)
            frame_diff = framediff(b_frame_gray,a_frame_gray)
        fcnt +=1
        if cv2.waitKey(1) & 0xFF == ord('q'):
            break
        #previous_frame = current_frame.copy()
        #ret, current_frame = cap.read()
    #print(check_diff)
    cap_d1.release()
    cap_d2.release()
    cv2.destroyAllWindows()
    
    print("Finish Compare .. absdiff")
    check_df1 = pd.read_csv("results/flow_"+videoList[0][:-4].split('/')[-1]+".csv")
    check_df2 = pd.read_csv("results/flow_"+videoList[1][:-4].split('/')[-1]+".csv")
    if check_diff==1:
        smae_flow_df = pd.concat([df1,df2])
        same_flow_df.to_csv("results/flow_merge_"+videoList[0][:-4].split('/')[-1]+".csv",index=False)
    print("All finish")
         
    
