How it works:

1. After running the program it will first execute Global.asax.cs file then FilterConfig.cs to RouteConfig.cs and 
  from RouteConfig.cs file it will go following action of controller that i populated in RouteConfig.cs file (controller = "Home", action = "Index")

2. After going Home Controller it will create object of DBEntities named as db. Then will go to Index action and
   create object of UserViewModel named as model. Then populate UserList and return Index view.

3. At the top of the Task list left corner there is Create New button. After clicking this button it will go Create 
   Action of Home Controller and return Create View with UserViewModel model. After inserting text fields clicking Save 
   button it will go post create action of Home controller. There is a method for mapping data & save data to Database.
   After Saving data it will redirect Action to Index.

4. In Task list there two button edit & Delete. After clicking edit button it will go edit action of home controller
   with Id parameter and get data form database by Id, mapping with UserViewModel it will return edit view with model.
   Then ckicking Update button it will go post edit action of Home controller.There is a method for mapping data & Update data to Database.
   After Updating data it will redirect Action to Index.

5. In Task list ckicking delete button it will go delete action of Home controller. After deleting data it will redirect Action to Index.