# Optical Recognition Character (OCR)
This is a real-world project. Confidential information is not disclosed.<br>
<b>Language:</b> C# <br>
<b>Framework:</b> .NET <br>
<b>Software Application Used:</b> Micorost Visual Studio

<br>
<h2> Program Description </h2>
Extract text from scanned pdf using OCR engines such as Tesseract and Iron OCR. By performing OCR, businesses are able to eliminate the need for manual data entry. All the data can be extracted from the documents and saved into the database automatically. It helps to save time and manpower.<br><br>

a. Tesseract
1. Convert pdf to image file (jpg/png) using Syncfusion library.
2. Crop the picture by defining the region coordinates.
3. Image processing to enhance the quality of the scanned pdf using ImageMagick library. (e.g. adjust brightness, contrast, remove noise, remove lines) 
4. Pass the processed image to Tesseract for OCR. The output will be saved in the txt file.

b. Iron OCR
1. Convert scanned pdf to searchable pdf by using Iron OCR.
2. Image processing. (If necessary only)
3. Define the coordinates to extract data from specific region.
4. Text extracted will be saved in the txt file.

<br>
<h2>Demo</h2>
<b>Input<br>
<img width="288" alt="2022-04-03 (10)" src="https://user-images.githubusercontent.com/70939387/161436006-7d702124-1ab4-49e4-8572-f8ea249e2f6f.png">
<br><br>
Output<br>
<img width="458" alt="2022-01-06 (2)" src="https://user-images.githubusercontent.com/70939387/148379427-033516be-7e84-4eca-af0e-8f394522197e.png">




