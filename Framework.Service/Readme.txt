

BLL services along with Database services is wrapped into this module. 

Strictly speaking, Web can only access BLL layer without comunicating with database services direclty,
but since there are many CRUD operation, Web project would directly call these database service interface.

In a big project, these two parts - BLL service and DB service could seperate with each other in order to make it more clear.



