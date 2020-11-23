import zipfile, re

srcFile = r'channel.zip' # 파일은 이미 존재해야한다
dstFile = r'text' # 생성할 압축파일의 경로 및 위치이다.

start = '90052'
origin = '.txt'
pat = re.compile(r'(?<=)[0-9]+')

zipf = zipfile.ZipFile(srcFile)
cont = zipf.read(start + origin).decode('utf-8')
comm = zipf.getinfo('90052.txt').comment.decode('utf-8')
number = pat.search(cont).group()

comments = []
comments += comm

print(cont + ' ' + comm)
while True:
    cont = zipf.read(number + origin).decode('utf-8')
    comm = zipf.getinfo(number + origin).comment.decode('utf-8')
    comments += comm
    print(cont + ' ' + "".join(comments))
    number = pat.search(cont).group()


zipf.close()