using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Lb4.UIModels.Abstract;

public class UIValidator
{
    public async Task<bool> IsValidateStudentUIParamsSuccessAsync(UIStudent uiStudent)
    {
        Task<bool> validName = ValidateStringSyntaxEnteredData(uiStudent.Name, nameof(uiStudent.Name));
        Task<bool> validLastname = ValidateStringSyntaxEnteredData(uiStudent.LastName, nameof(uiStudent.LastName));
        Task<bool> validPatronymic = ValidateStringSyntaxEnteredData(uiStudent.Patronymic, nameof(uiStudent.Patronymic));
        
        Task<bool> validCourseNumber = ValidateByteSyntaxEnteredData(uiStudent.CourseNumber);

        bool[] result = await Task.WhenAll(validName, validLastname, validPatronymic, validCourseNumber);

        return !result.Any(i => i.Equals(false));
    }
    
    public async Task<bool> IsValidateGroupUIParamsSuccessAsync(UIGroup uiGroup)
    {
        return await ValidateStringSyntaxEnteredData(uiGroup.GroupName, nameof(uiGroup.GroupName));
    }
    
    private async Task<bool> ValidateStringSyntaxEnteredData(string data, string paramName)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            MessageBox.Show("You must enter data in order to create a new object!", "Data error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        else if (data.Length < 3 || data.Length > 30)
        {
            MessageBox.Show($"{paramName} must have minimum 3 symbols and maximum 30", "Data error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        else return true;
    }
    
    private async Task<bool> ValidateByteSyntaxEnteredData(byte data)
    {
        if (data < 1 || data > 6)
        {
            MessageBox.Show($"Course number value must be between 1 and 6", "Data error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        return true;
    }
}