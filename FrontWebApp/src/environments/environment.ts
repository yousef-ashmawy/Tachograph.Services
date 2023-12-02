let PublishEnv = 'http://localhost:5015/';
export const environment = {
    authGatewayApi: PublishEnv,
    UserManagementBaseUrl: `${PublishEnv}api/UserManagement/`,
    TachographServicesBaseUrl: `${PublishEnv}api/TachographServices/`
};
export const UserManagementWebApis = {
    authApi: environment.UserManagementBaseUrl + 'Auth/LoginUser'
}
export const tachographservicesApis = {
    getAll: environment.TachographServicesBaseUrl + 'TachographRecord/GetAll',
    getAllDriverByFilter: environment.TachographServicesBaseUrl + 'TachographRecord/GetAllByFilter',
    getDayDriveTimeViolations: environment.TachographServicesBaseUrl + 'TachographRecord/GetDayDriveTimeViolations',
    getDayDriveTimeViolationsByFilter: environment.TachographServicesBaseUrl + 'TachographRecord/GetDayDriveTimeViolationsByFilter',
    getRestTimeViolations: environment.TachographServicesBaseUrl + 'TachographRecord/GetRestTimeViolations',
    getRestTimeViolationsByFilter: environment.TachographServicesBaseUrl + 'TachographRecord/GetRestTimeViolationsByFilter',
    getSingleDriveTimeViolations: environment.TachographServicesBaseUrl + 'TachographRecord/GetSingleDriveTimeViolations',
    getSingleDriveTimeViolationsByFilter: environment.TachographServicesBaseUrl + 'TachographRecord/GetSingleDriveTimeViolationsByFilter',
    getWeekDriveTimeViolations: environment.TachographServicesBaseUrl + 'TachographRecord/GetWeekDriveTimeViolations'
}

export const companiesApis = {
    GetAllApi: environment.UserManagementBaseUrl + 'Companies/' + 'GetAll',
    getByConditionApi: environment.UserManagementBaseUrl + 'Companies/' + 'GetByCondition',
    addCompanyApi: environment.UserManagementBaseUrl + 'Companies/' + 'Add',
    updateCompanyApi: environment.UserManagementBaseUrl + 'Companies/' + 'Update',
    getCompanyByIdApi: environment.UserManagementBaseUrl + 'Companies/' + 'GetById',
    getCompanyAndRidersStatistics: environment.UserManagementBaseUrl + 'Companies/' + 'GetCompanyAndRidersStatistics',

}