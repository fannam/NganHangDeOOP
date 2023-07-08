﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace NganHangDe.Extensions
{
    public class BindableRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty BindableTextProperty =
            DependencyProperty.Register(
                "BindableText",
                typeof(string),
                typeof(BindableRichTextBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnBindableTextChanged));

        public string BindableText
        {
            get => (string)GetValue(BindableTextProperty);
            set => SetValue(BindableTextProperty, value);
        }

        private bool _internalUpdate;

        public BindableRichTextBox()
        {
            // No need for additional setup without text wrapping
        }

        private static void OnBindableTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindableRichTextBox richTextBox && !richTextBox._internalUpdate)
            {
                richTextBox._internalUpdate = true;
                if (e.NewValue != null)
                {
                    richTextBox.Document.Blocks.Clear();
                    richTextBox.Document.Blocks.Add(new Paragraph(new Run((string)e.NewValue)));
                }
                else
                {
                    richTextBox.Document.Blocks.Clear();
                }
                richTextBox._internalUpdate = false;
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            if (!_internalUpdate)
            {
                _internalUpdate = true;
                TextRange textRange = new TextRange(Document.ContentStart, Document.ContentEnd);
                BindableText = textRange.Text;
                _internalUpdate = false;
            }
        }
    }
}