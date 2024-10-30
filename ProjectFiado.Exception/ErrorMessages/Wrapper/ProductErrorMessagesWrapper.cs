using ProjectFiado.Exceptions.ErrorMessages;

public class ProductErrorMessagesWrapper
{
    public static string ProductEmpty => ProductErrorMessages.Error_01___Product_Empty;
    public static string ProductEmptyName => ProductErrorMessages.Error_02___Product_Empty_Name;
    public static string InvalidPrice => ProductErrorMessages.Error_03____Product_Price_Invalid;
    public static string ProductBrandEmpty => ProductErrorMessages.Error_04___Product_Brand_Empty;
    public static string ProductDescriptionEmpty => ProductErrorMessages.Error_05___Product_Description_empty;
    public static string ProductNotFound => ProductErrorMessages.Error_06_Product_not_Found;
    public static string ProductsNotFoundList => ProductErrorMessages.Error_07_Products_not_found_List;
}
