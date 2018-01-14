// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using Microsoft.Azure;
using Microsoft.AzureStack.Management.Models;

namespace Microsoft.AzureStack.Management.Models
{
    /// <summary>
    /// Gallery item Get operation result.
    /// </summary>
    public partial class GalleryItemGetResult : AzureOperationResponse
    {
        private GalleryItemModel _galleryItem;
        
        /// <summary>
        /// Optional. Gallery item set of the parameters including
        /// GalleryItemUri.
        /// </summary>
        public GalleryItemModel GalleryItem
        {
            get { return this._galleryItem; }
            set { this._galleryItem = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the GalleryItemGetResult class.
        /// </summary>
        public GalleryItemGetResult()
        {
        }
    }
}
