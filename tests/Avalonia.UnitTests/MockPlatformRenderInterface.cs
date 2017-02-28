﻿using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media;
using Avalonia.Platform;
using Moq;

namespace Avalonia.UnitTests
{
    public class MockPlatformRenderInterface : IPlatformRenderInterface
    {
        public IFormattedTextImpl CreateFormattedText(
            string text,
            string fontFamilyName,
            double fontSize,
            FontStyle fontStyle,
            TextAlignment textAlignment,
            FontWeight fontWeight,
            TextWrapping wrapping,
            Size constraint)
        {
            var result = new Mock<IFormattedTextImpl>();
            result.Setup(x => x.WithConstraint(It.IsAny<Size>())).Returns(() => result.Object);
            return result.Object;
        }

        public IRenderTarget CreateRenderTarget(IEnumerable<object> surfaces)
        {
            return Mock.Of<IRenderTarget>();
        }

        public IRenderTargetBitmapImpl CreateRenderTargetBitmap(
            int width,
            int height,
            double dpiX,
            double dpiY)
        {
            return Mock.Of<IRenderTargetBitmapImpl>();
        }

        public IStreamGeometryImpl CreateStreamGeometry()
        {
            return new MockStreamGeometryImpl();
        }

        public IBitmapImpl LoadBitmap(Stream stream)
        {
            return Mock.Of<IBitmapImpl>();
        }

        public IBitmapImpl LoadBitmap(string fileName)
        {
            return Mock.Of<IBitmapImpl>();
        }
    }
}