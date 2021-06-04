﻿using System.Collections.Generic;
using Dit.Umb.MKulturProzent.Classics.Models.Poco;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Enum;
using Dit.Umb.ToolBox.Models.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.Modules
{
    public class DoubleSliderComponent : MutoboContentModule, IModule
    {
        public IEnumerable<TextImageSlide> Slides { get; set; }


        public int? Height => this.HasValue(DocumentTypes.DoubleSliderComponent.Fields.Height)
            ? this.Value<int?>(DocumentTypes.DoubleSliderComponent.Fields.Height)
            : null;

        public int? Interval => this.HasValue(DocumentTypes.DoubleSliderComponent.Fields.Interval)
            ? this.Value<int?>(DocumentTypes.DoubleSliderComponent.Fields.Interval) : null;



        public int? Width => this.HasValue(DocumentTypes.DoubleSliderComponent.Fields.Width)
            ? this.Value<int?>(DocumentTypes.DoubleSliderComponent.Fields.Width)
            : null;



        public string GetPictureNameSpace()
        {
            var result = "carousel-picture-";
            EGalleryType galleryType = EGalleryType.FullWidth;

            if (this.HasValue(DocumentTypes.DoubleSliderComponent.Fields.DisplayType))
            {
                galleryType = (EGalleryType)System.Enum.Parse(typeof(EGalleryType),
                    this.Value<string>(DocumentTypes.DoubleSliderComponent.Fields.DisplayType));

                if (galleryType == EGalleryType.Boxed)
                    result = "picture-";
            }

            return result;
        }



        public DoubleSliderComponent(IPublishedElement content) : base(content)
        {


        }
    }
}
