import re, requests

origin = 'http://www.pythonchallenge.com/pc/def/linkedlist.php?nothing='

url = 'http://www.pythonchallenge.com/pc/def/linkedlist.php?nothing=12345'

text = requests.get(url).text
pat = re.compile(r'(?<=)[0-9]+')
number = pat.search(text).group()

while(True):
    text = requests.get(origin + str(number)).text
    print(text)
    number = pat.search(text).group()


# If get error, You should change the url in this code.