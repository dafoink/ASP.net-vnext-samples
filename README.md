# ASP.net-vnext-samples MacOSX

## Video available on Youtube
http://youtu.be/wUtfKaO5G9Q

## Requirement
To use the projects the ASP.net vnext environment need to be proper installed. For further help and suggestion about
how to install it please find additional information on 

http://www.asp.net/vnext

https://github.com/aspnet/home

## Recommentation (Order matters): 

Remove all previous installed packages from dnu restore (On OSX they are located within the Home directory ~/.dnx/packages/ 
Only remove the content of this folder and not the folder itself :D.

Next navigate to the project folder by using cd PATH/TO/PROJECT e.g. cd ~/Desktop/HelloMvcSqlite 
Within the root project folder run the following commands

To restore the required packages
```
  dnu restore
```

To build the packages
```
  dnu build
```

Setup migration for Entity Framework (= ASP.net ORM) 
```
  dnx . ef migration add freeToUseName
```

Finally run the project
```
  dnx . kestrel
```
