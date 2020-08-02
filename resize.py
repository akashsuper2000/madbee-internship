from PIL import Image, ImageOps
import os

def resize(image_pil, width=120, height=50):
    '''
    Resize PIL image keeping ratio and using transparent background.
    '''
    ratio_w = width / image_pil.width
    ratio_h = height / image_pil.height
    if ratio_w < ratio_h:
        # It must be fixed by width
        resize_width = width
        resize_height = round(ratio_w * image_pil.height)
    else:
        # Fixed by height
        resize_width = round(ratio_h * image_pil.width)
        resize_height = height
    image_resize = image_pil.resize((resize_width, resize_height), Image.ANTIALIAS)
    background = Image.new('RGBA', (width, height), (255, 255, 255, 0))
    offset = (round((width - resize_width) / 2), round((height - resize_height) / 2))
    background.paste(image_resize, offset)
    return background

def fun(im_pth,i):
    im = Image.open(im_pth+'\\'+i).convert('RGBA')
    img = resize(im).convert('RGB')
    img.save('D:\\Education\\Others\\Summer\\edited\\'+i)
    


im_pth = "D:\\Education\\Others\\Summer\\images\\"
imgs = os.listdir(im_pth)
for i in imgs:
    fun(im_pth,i)

