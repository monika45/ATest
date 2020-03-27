
FreeSql.Generator -Razor 1 -NameOptions 1,0,0,1 -NameSpace ATest.Models -DB "MySql,Data Source=192.168.20.10;Port=3306;User ID=homestead;Password=secret; Initial Catalog=atest;Charset=utf8mb4; SslMode=none;Min pool size=1" -Filter View+StoreProcedure -FileName "{name}.cs" 
