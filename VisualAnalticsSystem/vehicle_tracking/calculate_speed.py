import pandas as pd
import math


traj_df = pd.read_csv("vehicle_traj.csv")
traj_df.rename( columns={'Unnamed: 0':'idx'}, inplace=True )
#print(traj_df)

traj_df = traj_df.sort_values(by=['vehicle_id','idx'])

#print(traj_df)

def ClaculateDistance(x1,y1,x2,y2):
    # 두 점 사이의 거리 계산
    dist = math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
    a2 = 100
    a1 = 10
    dist = dist * a2 / a1
    return dist


#traj_data.iloc[2] #특정행 접근
#print(traj_df.iloc[0,1])

# traj_df 행 개수와 같은 speed_df 선언후 셀 값은 0으로 채움
speed_df = pd.DataFrame(0, index=range(len(traj_df)), columns=('idx','speed'))


for x in range(len(traj_df)-1):
    val1 = traj_df.iloc[x,1]  
    val2 = traj_df.iloc[x+1,1]
    #print("x",x,"     val1",val1, "val2", val2)
    if val1 == val2:
        #print("hello")
        #print("-----------")
        x1= traj_df.iloc[x,2]
        y1= traj_df.iloc[x,3]
        x2= traj_df.iloc[x+1,2]
        y2= traj_df.iloc[x+1,3]
        
        speed = round( ClaculateDistance(x1,y1,x2,y2) , 1)
        #threshold = 50     
        speed_df.iloc[x,1] = speed
        #if speed < threshold:
        #    speed_df.iloc[x,1] = speed
        #else:
        #    speed_df.iloc[x,1] = '10'


#print(speed_df)        

result = pd.concat([traj_df, speed_df], axis=1)



result = result.groupby(['vehicle_id'], as_index=False).mean()
#print(result)
result = result.drop(['xpos', 'ypos', 'idx'], axis=1)


result.to_csv('output.csv', sep=',', encoding='utf-8')