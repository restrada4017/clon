# WebApi.Adn

para ejecutar el programa hay que tener en cuanta las siguientes herramientas.

1. Visual studio 2022 o visual studio code
2. Docker desktop
3. .net core 6.0

- Para iniciar la aplicacion es necesiario ejecutar el docker-compose ya que se levantan las imagenes de redis y postgresql

![image](https://user-images.githubusercontent.com/15368038/194885066-e34e0ad7-2f0c-4012-a51c-7dbab7f7f34b.png)

- La estructura del projecto se puede visualizar:

![image](https://user-images.githubusercontent.com/15368038/194885429-8d00744d-bb92-4b39-a4e3-82bd9e1e9afa.png)

- Cuando se ejecuta la aplicacion la base de datos es creada en el docker de postgresql y podemos acceder a esta por el pgadmin instalado en el docker compose

![image](https://user-images.githubusercontent.com/15368038/194886661-d245186c-ab19-4d95-b7c5-771f02f17f1e.png)

-  se puede probar la aplicacion por postmant o por el swagger que levanta la aplicacion

 1. json no es clon:
     {
       "adn":["WSYEWW","EWWYYY","EYWSSY","WSYWEY","WESSYY","YWEESS"]
     }
 
 2. json clon

    {
      "adn":["WSYEWW","EWWYYY","EYWSSY","WSYWEY","WESSYY","YEEEES"]
    }

Postman

![image](https://user-images.githubusercontent.com/15368038/194887279-d1ce2505-e7ec-4589-bdc3-d98db50e1533.png)

swagger

![image](https://user-images.githubusercontent.com/15368038/194887461-58a42654-3927-4b6f-be25-5cbb640bc398.png)


