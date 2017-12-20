/*
This file is part of the iText (R) project.
Copyright (c) 1998-2017 iText Group NV
Authors: iText Software.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
using System;
using iText.IO.Font;
using iText.IO.Image;
using iText.IO.Util;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Xobject;
using iText.Kernel.Utils;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Test;

namespace iText.Layout {
    public class AlignmentTest : ExtendedITextTest {
        public static readonly String sourceFolder = iText.Test.TestUtil.GetParentProjectDirectory(NUnit.Framework.TestContext
            .CurrentContext.TestDirectory) + "/resources/itext/layout/AlignmentTest/";

        public static readonly String destinationFolder = NUnit.Framework.TestContext.CurrentContext.TestDirectory
             + "/test/itext/layout/AlignmentTest/";

        [NUnit.Framework.OneTimeSetUp]
        public static void BeforeClass() {
            CreateDestinationFolder(destinationFolder);
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void JustifyAlignmentTest01() {
            String outFileName = destinationFolder + "justifyAlignmentTest01.pdf";
            String cmpFileName = sourceFolder + "cmp_justifyAlignmentTest01.pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            Document document = new Document(pdfDocument);
            Paragraph paragraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
            for (int i = 0; i < 21; i++) {
                paragraph.Add(new Text("Hello World! Hello People! " + "Hello Sky! Hello Sun! Hello Moon! Hello Stars!").SetBackgroundColor
                    (ColorConstants.RED));
            }
            document.Add(paragraph);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void JustifyAlignmentTest02() {
            String outFileName = destinationFolder + "justifyAlignmentTest02.pdf";
            String cmpFileName = sourceFolder + "cmp_justifyAlignmentTest02.pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            Document document = new Document(pdfDocument);
            Paragraph paragraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
            paragraph.Add(new Text("Hello World!")).Add(new Text(" ")).Add(new Text("Hello People! ")).Add("End");
            document.Add(paragraph);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void JustifyAlignmentTest03() {
            String outFileName = destinationFolder + "justifyAlignmentTest03.pdf";
            String cmpFileName = sourceFolder + "cmp_justifyAlignmentTest03.pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            Document document = new Document(pdfDocument);
            Paragraph paragraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
            for (int i = 0; i < 21; i++) {
                paragraph.Add(new Text("Hello World! Hello People! " + "Hello Sky! Hello Sun! Hello Moon! Hello Stars!").SetBorder
                    (new SolidBorder(ColorConstants.GREEN, 0.1f))).SetMultipliedLeading(1);
            }
            document.Add(paragraph);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void JustifyAlignmentTest04() {
            String outFileName = destinationFolder + "justifyAlignmentTest04.pdf";
            String cmpFileName = sourceFolder + "cmp_justifyAlignmentTest04.pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            Document document = new Document(pdfDocument);
            Paragraph paragraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
            for (int i = 0; i < 21; i++) {
                paragraph.Add(new Text("Hello World! Hello People! " + "Hello Sky! Hello Sun! Hello Moon! Hello Stars!")).
                    SetFixedLeading(24);
            }
            document.Add(paragraph);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void JustifyAlignmentForcedNewlinesTest01() {
            String outFileName = destinationFolder + "justifyAlignmentForcedNewlinesTest01.pdf";
            String cmpFileName = sourceFolder + "cmp_justifyAlignmentForcedNewlinesTest01.pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            Document document = new Document(pdfDocument);
            Paragraph paragraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
            paragraph.Add("Video provides a powerful way to help you prove your point. When you click Online Video, you can paste in the embed code for the video you want to add. You can also type a keyword to search online for the video that best fits your document.\n"
                 + "To make your document look professionally produced, Word provides header, footer, cover page, and text box designs that complement each other. For example, you can add a matching cover page, header, and sidebar. Click Insert and then choose the elements you want from the different galleries.\n"
                 + "Themes and styles also help keep your document coordinated. When you click Design and choose a new Theme, the pictures, charts, and SmartArt graphics change to match your new theme. When you apply styles, your headings change to match the new theme.\n"
                 + "Save time in Word with new buttons that show up where you need them. To change the way a picture fits in your document, click it and a button for layout options appears next to it. When you work on a table, click where you want to add a row or a column, and then click the plus sign.\n"
                 + "Reading is easier, too, in the new Reading view. You can collapse parts of the document and focus on the text you want. If you need to stop reading before you reach the end, Word remembers where you left off - even on another device.\n"
                );
            document.Add(paragraph);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void JustifyAllTest01() {
            String outFileName = destinationFolder + "justifyAllTest01.pdf";
            String cmpFileName = sourceFolder + "cmp_justifyAllTest01.pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            Document document = new Document(pdfDocument);
            Paragraph paragraph = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED_ALL);
            paragraph.Add("Video provides a powerful way to help you prove your point. When you click Online Video, you can paste in the embed code for the video you want to add. You can also type a keyword to search online for the video that best fits your document.\n"
                 + "To make your document look professionally produced, Word provides header, footer, cover page, and text box designs that complement each other. For example, you can add a matching cover page, header, and sidebar. Click Insert and then choose the elements you want from the different galleries.\n"
                 + "Themes and styles also help keep your document coordinated. When you click Design and choose a new Theme, the pictures, charts, and SmartArt graphics change to match your new theme. When you apply styles, your headings change to match the new theme.\n"
                 + "Save time in Word with new buttons that show up where you need them. To change the way a picture fits in your document, click it and a button for layout options appears next to it. When you work on a table, click where you want to add a row or a column, and then click the plus sign.\n"
                 + "Reading is easier, too, in the new Reading view. You can collapse parts of the document and focus on the text you want. If you need to stop reading before you reach the end, Word remembers where you left off - even on another device.\n"
                );
            document.Add(paragraph);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void JustifyAllTest02() {
            String outFileName = destinationFolder + "justifyAllTest02.pdf";
            String cmpFileName = sourceFolder + "cmp_justifyAllTest02.pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            Document document = new Document(pdfDocument);
            PdfFont type0 = PdfFontFactory.CreateFont(sourceFolder + "/../fonts/NotoSans-Regular.ttf", PdfEncodings.IDENTITY_H
                );
            PdfFont simpleFont = PdfFontFactory.CreateFont(sourceFolder + "/../fonts/NotoSans-Regular.ttf", true);
            Paragraph paragraph = new Paragraph().SetSpacingRatio(1).SetTextAlignment(TextAlignment.JUSTIFIED_ALL);
            paragraph.Add("If you need to stop reading before you reach the end");
            document.Add(paragraph.SetFont(type0));
            paragraph.SetFont(simpleFont);
            document.Add(paragraph);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void BlockAlignmentTest01() {
            String outFileName = destinationFolder + "blockAlignmentTest01.pdf";
            String cmpFileName = sourceFolder + "cmp_blockAlignmentTest01.pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            Document document = new Document(pdfDocument);
            List list = new List(ListNumberingType.GREEK_LOWER);
            for (int i = 0; i < 10; i++) {
                list.Add("Item # " + (i + 1));
            }
            list.SetWidth(250);
            list.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            list.SetBackgroundColor(ColorConstants.GREEN);
            document.Add(list);
            list.SetHorizontalAlignment(HorizontalAlignment.RIGHT).SetBackgroundColor(ColorConstants.RED);
            list.SetTextAlignment(TextAlignment.CENTER);
            document.Add(list);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void BlockAlignmentTest02() {
            String outFileName = destinationFolder + "blockAlignmentTest02.pdf";
            String cmpFileName = sourceFolder + "cmp_blockAlignmentTest02.pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            Document document = new Document(pdfDocument);
            Div div = new Div();
            PdfImageXObject xObject = new PdfImageXObject(ImageDataFactory.CreateJpeg(UrlUtil.ToURL(sourceFolder + "Desert.jpg"
                )));
            iText.Layout.Element.Image image1 = new iText.Layout.Element.Image(xObject, 100).SetHorizontalAlignment(HorizontalAlignment
                .RIGHT);
            iText.Layout.Element.Image image2 = new iText.Layout.Element.Image(xObject, 100).SetHorizontalAlignment(HorizontalAlignment
                .CENTER);
            iText.Layout.Element.Image image3 = new iText.Layout.Element.Image(xObject, 100).SetHorizontalAlignment(HorizontalAlignment
                .LEFT);
            div.Add(image1).Add(image2).Add(image3);
            document.Add(div);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void ImageAlignmentTest01() {
            String outFileName = destinationFolder + "imageAlignmentTest01.pdf";
            String cmpFileName = sourceFolder + "cmp_imageAlignmentTest01.pdf";
            PdfWriter writer = new PdfWriter(outFileName);
            PdfDocument pdfDoc = new PdfDocument(writer);
            Document doc = new Document(pdfDoc);
            PdfImageXObject xObject = new PdfImageXObject(ImageDataFactory.CreateJpeg(UrlUtil.ToURL(sourceFolder + "Desert.jpg"
                )));
            iText.Layout.Element.Image image = new iText.Layout.Element.Image(xObject, 100).SetHorizontalAlignment(HorizontalAlignment
                .RIGHT);
            doc.Add(image);
            doc.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void FloatAlignmentTest01() {
            String outFileName = destinationFolder + "floatAlignmentTest01.pdf";
            String cmpFileName = sourceFolder + "cmp_floatAlignmentTest01.pdf";
            PdfWriter writer = new PdfWriter(outFileName);
            PdfDocument pdfDoc = new PdfDocument(writer);
            pdfDoc.SetDefaultPageSize(new PageSize(350, 450));
            Document doc = new Document(pdfDoc);
            AddFloatAndText(doc, FloatPropertyValue.RIGHT);
            AddFloatAndText(doc, FloatPropertyValue.LEFT);
            doc.Add(new AreaBreak());
            doc.Add(new Paragraph("All lines after this one have first line indent = 20. " + "Float left is correct, right is not."
                ));
            doc.SetProperty(Property.FIRST_LINE_INDENT, 20f);
            AddFloatAndText(doc, FloatPropertyValue.RIGHT);
            // TODO DEVSIX-1732: Alignment is incorrect because indent is replaced by float adjustment
            AddFloatAndText(doc, FloatPropertyValue.LEFT);
            doc.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff"));
        }

        private static void AddFloatAndText(Document doc, FloatPropertyValue? floatPropertyValue) {
            Div div = new Div();
            div.SetWidth(150).SetHeight(120);
            div.SetProperty(Property.FLOAT, floatPropertyValue);
            div.SetBorder(new SolidBorder(1));
            doc.Add(div);
            doc.Add(new Paragraph("Left aligned.").SetTextAlignment(TextAlignment.LEFT));
            doc.Add(new Paragraph("Right aligned.").SetTextAlignment(TextAlignment.RIGHT));
            doc.Add(new Paragraph("Center aligned.").SetTextAlignment(TextAlignment.CENTER));
            doc.Add(new Paragraph("Justified. " + "The text is laid out using the correct width, but  the alignment value uses the full width."
                ).SetTextAlignment(TextAlignment.JUSTIFIED));
        }
    }
}
