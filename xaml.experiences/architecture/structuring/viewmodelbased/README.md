# View - ViewModel structure
This a convention where you create folders / namespaces for your views and view models. This approach is most 
suitable for smaller projects that has a limited feature-set.

This project is organized the following way:
- DataModels - The data transfer objects of the project, this is slim classes with little to no logic.
- Services - The service classes that can be used to add, get, remove or update data. Can also be verification services
- ViewModels - Classes that is used as a glue between the view and the models (data models and services). This class 
also has the logic in order for the view to be updated whenever data is changed. 
- Views - The UI layers