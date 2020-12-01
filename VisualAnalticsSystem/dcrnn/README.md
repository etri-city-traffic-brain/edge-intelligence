
# 교통 네트워크 모델링 기반 시공간 교통 네트워크 예측
- 교통 네트워크의 시공간 의존성과 확산 프로세스를 모델링하여         미래의 교통 네트워크를 예측하는 코드

## 실행 환경
- scipy>=0.19.0
- numpy>=1.12.1
- pandas>=0.19.2
- statsmodels>=0.11.0
- PyYAML=5.3
- Keras-Applications>=1.0.8
- Keras-Preprocessing>=1.1.0
- tb-nightly=2.2.0a20200106
- tensorboard=1.7.0
- tensorflow=1.7.0
- tensorflow-tensorboard=0.1.8
- tf-estimator-nightly=2.1.0.dev2020012309
- tf-nightly-gpu=2.2.0.dev20200127
- h5py=2.10.0


## 사전 작업
+ vehicle_tracking에서 생성된 교통 흐름 데이터
+ 교차로의 id(data/sensor_graph/graph_sensor_ids.txt) - 가상 네트워크의 노드 생성
+ 교차로간 거리(data/sensor_graph/distance.csv) - 가상 네트워크의 엣지 정보 생성
+ 교차로간 직접 연결 정보(data/sensor_graph/adj_mx.pkl)
+ 도로별 차량 속도 또는 교통량(data/sensor_graph/data.h5)


## 사용법
- 트레이닝/테스트 데이터 셋 분리
```
python -m scripts.generate_training_data
```
- 그래프 생성
```
python -m scripts.gen_adj_mx
```
- 모델 훈련
```
python dcrnn_train.py
```
- 모델 예측
```
python run_demo.py
```
- 성능 평가
```
python -m scripts.eval_baseline_methods
```
