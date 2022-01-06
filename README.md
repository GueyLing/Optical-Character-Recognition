Extract text from scanned pdf 
Three methods used (Tesseract, Iron OCR, Google Vision API)

a. 
Tesseract is a popular open source library for OCR.
1. Convert pdf to image file (jpg/png) using Syncfusion library.
2. Crop the picture by defining the region coordinates.
3. Image processing to enhance the quality of the scanned pdf using ImageMagick library. (e.g. adjust brightness, contrast, remove noise, remove lines) 
4. Pass the processed image to Tesseract for OCR. The output will be saved in the txt file.

Input

![actual](https://user-images.githubusercontent.com/70939387/148378097-f1df97de-9986-45e8-b965-20d395fa2e4d.png)

Output

<img width="458" alt="2022-01-06 (2)" src="https://user-images.githubusercontent.com/70939387/148379427-033516be-7e84-4eca-af0e-8f394522197e.png">


b. Iron OCR
1. Convert scanned pdf to searchable pdf by using Iron OCR.
2. Image processing. (If necessary only)
3. Define the coordinates to extract data from specific region.
4. Text extracted will be saved in the txt file.

c. Google Vision API
1. Setup on Google.
2. Install Google Vision API package on Visual Studio and pass the credential path. OCR is performed.


