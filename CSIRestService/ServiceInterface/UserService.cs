namespace CSIRestService.ServiceInterface
{
    interface IUserService
    {
        void RegisterUser();

        void LoginUser();

        void ValidateUser();

        void IsUserExists();

        void GetUserInfo();

        void UpdateUser();

        void DeleteUser();

        void GetAllUsers();

        void AddUser();


    }
}
