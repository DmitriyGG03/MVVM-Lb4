using System;
using System.Collections.Generic;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.Domain.Models.Base;

namespace MVVM_Lb4.UIModels;

public class UIGroup : ModelBase
{
    public Guid GroupId { get; set; }
    public string GroupName { get; set; }
}