# CCTV 영상에서 교통 흐름 데이터를 생성

- 입력 CCTV 영상에 차량을 탐지 및 추적하여 교통 흐름 데이터를 생성하는 코드
- 차량은 버스, 트럭, 오토바이, 승용차로 분류할 수 있음

## 실행 환경
- cuda >= 10.0
- Python >= 3.6
- scikit_learn==0.21.3
- numpy
- matplotlib
- torch
- torchvision
- terminaltables
- pillow
- tqdm
- numba
- fire
- filterpy
- opencv-python
- scikit-image
- pytesseract
- PyQt5
- pandas

## 참고 사항
- 차량 탐지를 위한 학습 데이터 셋은 weights 폴더에 저장해야 하며, 기본 학습 데이터셋은 아래 url에서 확인할 수 있음
```
yolov3-darknet https://github.com/pjreddie/darknet
yolov3-pytorch https://github.com/eriklindernoren/PyTorch-YOLOv3
```
- 아래 소스코드를 수정 및 확장함
```
https://github.com/wsh122333/Multi-type_vehicles_flow_statistics
```

## 사용법

- 위 git refrence에서 제공하는 기본 GUI 버전 프로그램
```
python app.py
```
- reference 버전을 보완 및 확장한 프로그램
```
python app_modify_fin_2.py
```
- CCTV 영상을 대상으로 app_modify_fin_2.py를 실행하면 교통 흐름 데이터를 얻을 수 있음
