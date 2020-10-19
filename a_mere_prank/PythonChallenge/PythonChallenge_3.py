import requests as rq

url = 'http://www.pythonchallenge.com/pc/def/equality.html'

response = rq.get(url)
print(response)
text = response.text

print(text)

start = text.find('kAewtloYgcFQaJNhHVGxXDiQmzjfcpYbzxlWrVcqsmUbCunkfxZW')
end = text.find('hziiavGSYofPNeKsTXruMUumRRPQJzvSzJkKbtSipiqBd')

real = ""

find = text[start:end]

for i in range(7, len(find) - 1):
    if find[i-7].islower() and find[i-6].isupper() and find[i-5].isupper() and find[i-4].isupper() and find[i-3].islower() and find[i-2].isupper() and find[i-1].isupper() and find[i].isupper() and find[i + 1].islower():
        real += find[i-3]

print(real)
