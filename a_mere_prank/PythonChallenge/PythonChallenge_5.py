import pickle
import requests

url = "http://www.pythonchallenge.com/pc/def/banner.p"

text = requests.get(url).text
text = text.encode()

lst = pickle.loads(text)

for l in lst:
    for w in l:
        print(w[0] * w[1], end = "")
    print("")