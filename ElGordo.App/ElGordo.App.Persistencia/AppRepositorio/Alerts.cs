using ElGordo.App.Dominio;

namespace ElGordo.App.Persistencia
{
    public static class Alerts
    {
        public static string ShowAlert(Alert obj, string message)
        {
            const string alert1 = "<div class='alert ";
            string alert2 = " alert-dismissable fade show' id='alert'><button type='button' class='close' data-dismiss='alert'>&times;</button> " + message + "</div>";
            switch (obj)
            {
                case Alert.Primary:
                    return alert1 + "alert-primary" + alert2;
                case Alert.Success:
                    return alert1 + "alert-success" + alert2;
                case Alert.Danger:
                    return alert1 + "alert-danger" + alert2;
                case Alert.Info:
                    return alert1 + "alert-info" + alert2;
                case Alert.Warning:
                    return alert1 + "alert-warning" + alert2;
                default:
                    break;
            }
            return alert1 + alert2;
        }
    }
}