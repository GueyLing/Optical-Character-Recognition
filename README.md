Extract text from scanned pdf 
Three methods used (Tesseract, Iron OCR, Google Vision API)

a. Tesseract
Tesseract is a popular open source library for OCR.
1. Convert pdf to image file (jpg/png) using Syncfusion library.
2. Crop the picture by defining the region coordinates.
3. Image processing to enhance the quality of the scanned pdf using ImageMagick library. (e.g. adjust brightness, contrast, remove noise, remove lines) 
4. Pass the processed image to Tesseract for OCR. The output will be saved in the txt file.

b. Iron OCR
1. Convert scanned pdf to searchable pdf by using Iron OCR.
2. Image processing.
3. Define the coordinates to extract data from specific region.
4. Text extracted will be saved in the txt file.

c. Google Vision API
1. Setup on Google.
2. Install Google Vision API package on Visual Studio and pass the credential path. OCR is performed.

