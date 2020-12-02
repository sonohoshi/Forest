from PIL import Image

img = Image.open('oxygen.png')

count = 0

print(img.size)
for x in range(0, img.size[0]):
    pixel = img.getpixel((x, 95 / 2))
    if pixel[0] == pixel[1] and pixel[1] == pixel[2] and count % 7 == 0:
        count = 1
        print(chr(pixel[0]), end = '')
    elif count % 7 != 0:
        count += 1

print()
lst = [105, 110, 116, 101, 103, 114, 105, 116, 121]

real = ''
for i in lst:
    real += chr(i)

print(real)
