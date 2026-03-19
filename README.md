using CarRental.Core.Models;
using CarRental.Core.Validation;

namespace CarRental.Core.Migration;

public static class RentalNormalizer
{
    public static bool Normalize(Rental rental)
    {
        bool changed = false;

        // Проверка CustomerName
        if (rental.CustomerName == null)
        {
            rental.CustomerName = "";
            changed = true;
        }
        
        var nameTrim = rental.CustomerName.Trim();
        if (nameTrim != rental.CustomerName)
        {
            rental.CustomerName = nameTrim;
            changed = true;
        }
        
        if (rental.CustomerName.Length > CarValidator.CustomerNameMaxLength)
        {
            rental.CustomerName = rental.CustomerName.Substring(0, CarValidator.CustomerNameMaxLength);
            changed = true;
        }

        // Проверка CustomerPhone
        if (rental.CustomerPhone == null)
        {
            rental.CustomerPhone = "";
            changed = true;
        }
        
        var phoneTrim = rental.CustomerPhone.Trim();
        if (phoneTrim != rental.CustomerPhone)
        {
            rental.CustomerPhone = phoneTrim;
            changed = true;
        }
        
        if (rental.CustomerPhone.Length > CarValidator.CustomerPhoneMaxLength)
        {
            rental.CustomerPhone = rental.CustomerPhone.Substring(0, CarValidator.CustomerPhoneMaxLength);
            changed = true;
        }

        // Проверка дат (если дата в прошлом, ставим сегодня)
        if (rental.StartDate < DateTime.Today)
        {
            rental.StartDate = DateTime.Today;
            changed = true;
        }
        
        if (rental.EndDate <= rental.StartDate)
        {
            rental.EndDate = rental.StartDate.AddDays(1);
            changed = true;
        }

        // Пересчет TotalPrice если нужно
        if (rental.TotalPrice <= 0)
        {
            rental.TotalPrice = 1000;
            changed = true;
        }

        return changed;
    }
}