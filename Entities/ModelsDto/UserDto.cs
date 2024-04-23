using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public RoomType RoomType { get; set; } // Oda tipini temsil eden bir enum

        //rezervasyonun başarı durumunu belirtme
        public bool IsReservationSuccessful { get; set; }
        public string Message { get; set; } // Kullanıcıya gösterilecek mesaj
    }
}
