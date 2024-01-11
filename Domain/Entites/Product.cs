namespace Domain.Entites
{
    public class Product: IEntity
    {
        private string _name;
        public decimal _price;
        public string? _imageUrl;
        public int Id { get; init; }
        public string Name
        {
            get => _name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым", nameof(value));
                if (value.Length is < 3 or > 100)
                    throw new ArgumentException("Имя должно содержать от 3 до 100 символов", nameof(value));

                _name = value;
            }
        }
        public decimal Price 
        {
            get => _price;
            set
            {
                if (value is > 0)
                    throw new ArgumentException("Цена должна быть больше 0", nameof(value));
                _price = value;
            }
            
        }
        public string ImageUrl 
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
            }
        }

    }
}
