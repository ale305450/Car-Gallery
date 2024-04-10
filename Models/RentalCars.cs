namespace Learing_Core.Models
{
    public class RentalCar
    {
        public int Id { get; set; }
        public string Length { get; set; }
        public ICollection<Car> CarRent { get; set; }
    }
}
