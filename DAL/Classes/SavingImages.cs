using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Classes;

public class SavingImages
{
    [Key] // מזהה שזה מפתח ראשי
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // מספור אוטומטי
    public int Id { get; set; }

    public string OrderCode { get; set; }

    public Byte[] Images { get; set; }
    public int ProcessStatus { get; set; }

    public string Size { get; set; }


    public SavingImages() { }
    public SavingImages(string OrderCode, Byte[] images, string size)
    {
        this.OrderCode = OrderCode;
        this.Images = images;
        this.ProcessStatus = 1;
        Size = size;
    }

}
