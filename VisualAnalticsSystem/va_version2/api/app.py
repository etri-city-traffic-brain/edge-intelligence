from flask import *
from flask_cors import CORS, cross_origin
import json
import requests
import random

app = Flask(__name__)
if __name__ == '__main__':  
  app.run(debug=True)
CORS(app)

@app.route('/')
def index():
  return render_template('index.html')

@app.route('/video/<channel>')
def video(channel):
  '''source = ''
  with open('static/data.json', 'r', encoding='utf-8') as handle:
    data = json.load(handle)[channel]
    liveParam = data['liveEncryptedString']

    url = 'http://cctvsec.ktict.co.kr/' + channel + '/' + liveParam
    headers = {
      'Accept': '*/*',
      'Accept-Encoding': 'gzip, deflate, br',
      'Accept-Language': 'ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7',
      'Connection': 'keep-alive',
      'Host': 'cctvsec.ktict.co.kr',
      'Set-Fetch-Dest': 'empty',
      'Set-Fetch-Mode': 'cors',
      'Set-Fetch-Site': 'cross-site',
      'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36'
    }
    response = requests.get(url, headers=headers)
    source = response.url'''
  
  source = ''
  url = 'https://map.naver.com/v5/api/cctv/list?channel=' + channel
  data = requests.get(url).json()

  for cctv in data['message']['result']['cctvList']:
    if cctv['channel'] == int(channel):
      liveParam = cctv['liveEncryptedString']
      if liveParam is None:
        liveParam = cctv['encryptedString']

      url = 'http://cctvsec.ktict.co.kr/' + channel + '/' + liveParam
      print('http://cctvsec.ktict.co.kr/' + channel + '/' + liveParam)

      headers = {
        'Accept': '*/*',
        'Accept-Encoding': 'gzip, deflate, br',
        'Accept-Language': 'ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7',
        'Connection': 'keep-alive',
        'Host': 'cctvsec.ktict.co.kr',
        'Set-Fetch-Dest': 'empty',
        'Set-Fetch-Mode': 'cors',
        'Set-Fetch-Site': 'cross-site',
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36'
      }
      response = requests.get(url, headers=headers)
      source = response.url

      print(source)
      return source

  return ''

@app.route('/generate/traffic_data')
def generateTrafficData():
  trafficData = []
  with open('static/place_data.json', 'r', encoding='utf-8') as handle:
    placeData = json.load(handle)
    for place in placeData.values():
      for dest in place['linked']:
        traffic = {}
        traffic['from'] = place['name']
        traffic['to'] = dest
        traffic['traffic'] = []
        for i in range(0, 24):
          tbp = {}
          tbp['time'] = i
          tbp['volume'] = random.randrange(5, 30)
          tbp['avs'] = 40 - tbp['volume']
          traffic['traffic'].append(tbp)
        trafficData.append(traffic)
  with open('static/traffic_data.json', 'w', encoding='utf-8') as handle:
    handle.write(json.dumps(trafficData, ensure_ascii=False, indent='\t'))
  print('Traffic data generated')
  return jsonify(trafficData)