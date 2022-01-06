Extract text from scanned pdf 
Three methods used (Tesseract, Iron OCR, Google Vision API)

1. Tesseract
Tesseract is a popular open source library for OCR.
a. Convert pdf to image file (jpg/png) using Syncfusion library.
b. Crop the picture by defining the region coordinates.
c. Image processing to enhance the quality of the scanned pdf using ImageMagick library. (e.g. adjust brightness, contrast, remove noise, remove lines) 
d. Pass the processed image to Tesseract for OCR. The output will be saved in the txt file.

2. Iron OCR
a. Convert scanned pdf to searchable pdf by using Iron OCR.
b. Image processing.
c. Define the coordinates to extract data from specific region.
d. Text extracted will be saved in the txt file.

3. Google Vision API
a. Setup on Google.
b. Install Google Vision API package on Visual Studio and pass the credential path. OCR is performed.

