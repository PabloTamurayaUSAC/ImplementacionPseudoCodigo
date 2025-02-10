using System;
using Gtk;

public class Menu1 : Window
{
    public Menu1() : base("Prueba de Listas")
    {
        SetDefaultSize(600, 400);
        Button button1 = new Button("Lista Contigua");
        button1.Clicked += (sender, e) =>
        {
            Window menu2 = new Menu2(0);
            menu2.DeleteEvent += delegate { Application.Quit(); };
            menu2.SetPosition(WindowPosition.CenterAlways);
            this.Hide();
        };
        Button button2 = new Button("Lista Ligada");
        button2.Clicked += (sender, e) =>
        {
            Window menu2 = new Menu2(1);
            menu2.DeleteEvent += delegate { Application.Quit(); };
            menu2.SetPosition(WindowPosition.CenterAlways);
            this.Hide();
        };
        Button button3 = new Button("Lista Doblemente Ligada");
        button3.Clicked += (sender, e) =>
        {
            Window menu2 = new Menu2(2);
            menu2.DeleteEvent += delegate { Application.Quit(); };
            menu2.SetPosition(WindowPosition.CenterAlways);
            this.Hide();
        };
        Button button4 = new Button("Lista Indexada");
        button4.Clicked += (sender, e) =>
        {
            Window menu2 = new Menu2(3);
            menu2.DeleteEvent += delegate { Application.Quit(); };
            menu2.SetPosition(WindowPosition.CenterAlways);
            this.Hide();
        };
        VBox conV = new VBox();
        conV.PackStart(new Label("Elija la Lista a Probar:"), false, false, 5);
        conV.PackStart(button1, false, false, 5);
        conV.PackStart(button2, false, false, 5);
        conV.PackStart(button3, false, false, 5);
        conV.PackStart(button4, false, false, 5);
        Add(conV);
        ShowAll();
    }
}

public class Menu2 : Window
{
    public int tipo, cantidad;
    public int[] datos, atras, delante, index;
    public Menu2(int tipo) : base("Editor de Lista")
    {
        this.tipo = tipo;
        datos = new int[10];
        atras = new int[10];
        delante = new int[10];
        index = new int[10];
        cantidad = 0;

        VBox conV = new VBox();
        switch (tipo){
            case 0:
                conV.PackStart(new Label("Prueba de Lista Contigua"), false, false, 5);
                break;
            case 1:
                conV.PackStart(new Label("Prueba de Lista Ligada"), false, false, 5);
                break;
            case 2:
                conV.PackStart(new Label("Prueba de Lista Doble Ligada"), false, false, 5);
                break;
            case 3:
                conV.PackStart(new Label("Prueba de Lista Indexada"), false, false, 5);
                break;
        }
        Button button1 = new Button("Insertar");
        button1.Clicked += (sender, e) =>
        {
            if (cantidad < 10){
                Window insertar = new Insertar(this);
                insertar.DeleteEvent += delegate { Application.Quit(); };
                insertar.SetPosition(WindowPosition.CenterAlways);
                this.Hide();
            }
        };
        conV.PackStart(button1, false, false, 5);
        Button button2 = new Button("Eliminar");
        button2.Clicked += (sender, e) =>
        {
            if (cantidad > 0){
                Window eliminar = new Eliminar(this);
                eliminar.DeleteEvent += delegate { Application.Quit(); };
                eliminar.SetPosition(WindowPosition.CenterAlways);
                this.Hide();
            }
        };
        conV.PackStart(button2, false, false, 5);
        Button button3 = new Button("Mostrar los Datos");
        button3.Clicked += (sender, e) =>
        {
            Window mostrar = new Mostrar(this);
            mostrar.DeleteEvent += delegate { Application.Quit(); };
            mostrar.SetPosition(WindowPosition.CenterAlways);
            this.Hide();
        };
        conV.PackStart(button3, false, false, 5);
        Button button = new Button("Regresar");
        button.Clicked += (sender, e) =>
        {
            Window menu1 = new Menu1();
            menu1.DeleteEvent += delegate { Application.Quit(); };
            menu1.SetPosition(WindowPosition.CenterAlways);
            this.Hide();
        };
        conV.PackStart(button, false, false, 5);
        SetDefaultSize(600, 400);
        Add(conV);
        ShowAll();
    }
}

public class Insertar : Window //completar
{
    public Insertar(Menu2 padre) : base("Insertar")
    {
        VBox conV = new VBox();
        SetDefaultSize(300, 200);
        Button button = new Button("Regresar");
        button.Clicked += (sender, e) =>
        {
            padre.Show();
            this.Hide();
        };
        string tipo = "";
        switch (padre.tipo){
            case 0:
                tipo = "Prueba de Lista Contigua";
                break;
            case 1:
                tipo = "Prueba de Lista Ligada";
                break;
            case 2:
                tipo = "Prueba de Lista Doble Ligada";
                break;
            case 3:
                tipo = "Prueba de Lista Index";
                break;            
        }
        conV.PackStart(new Label(tipo), false, false, 5);
        conV.PackStart(new Label("Ingrese un numero (Entero):"), false, false, 5);
        Entry entrada = new Entry();
        conV.PackStart(entrada, false, false, 5);
        Button buttonI = new Button("Insertar");
        buttonI.Clicked += (sender, e) =>
        {
            if (int.TryParse(entrada.Text, out int numero)){
                if (numero >=0){
                    padre.datos[padre.cantidad] = numero;
                    switch (padre.tipo){
                        case 0:
                            break;
                        case 1:
                            if(padre.cantidad > 0){
                                padre.delante[padre.cantidad-1]=padre.datos[padre.cantidad];
                            }
                            break;
                        case 2:
                            if(padre.cantidad > 0){
                                padre.atras[padre.cantidad]=padre.datos[padre.cantidad-1];
                                padre.delante[padre.cantidad-1]=padre.datos[padre.cantidad];
                            }
                            break;
                        case 3:
                            padre.index[padre.cantidad]=padre.cantidad;
                            break;            
                    }
                    padre.cantidad++;
                }
                padre.Show();
                this.Hide();
            }
        };
        conV.PackStart(buttonI, false, false, 5);
        conV.PackStart(button, false, false, 5);
        Add(conV);
        ShowAll();
    }
}

public class Eliminar : Window //completar
{
    public Eliminar(Menu2 padre) : base("Eliminar")
    {
        VBox conV = new VBox();
        SetDefaultSize(300, 200);
        Button button = new Button("Regresar");
        button.Clicked += (sender, e) =>
        {
            padre.Show();
            this.Hide();
        };
        string tipo = "";
        switch (padre.tipo){
            case 0:
                tipo = "Prueba de Lista Contigua";
                break;
            case 1:
                tipo = "Prueba de Lista Ligada";
                break;
            case 2:
                tipo = "Prueba de Lista Doble Ligada";
                break;
            case 3:
                tipo = "Prueba de Lista Index";
                break;            
        }
        conV.PackStart(new Label(tipo), false, false, 5);
        conV.PackStart(new Label("Ingrese la posicion del dato a Eliminar (0-9):"), false, false, 5);
        Entry entrada = new Entry();
        conV.PackStart(entrada, false, false, 5);
        Button buttonI = new Button("Eliminar");
        buttonI.Clicked += (sender, e) =>
        {
            if (int.TryParse(entrada.Text, out int numero)){
                if (numero <= padre.cantidad){
                    padre.datos[numero] = 0;
                    for (int i=numero; i < padre.cantidad-1; i++){
                        padre.datos[i]=padre.datos[i+1];
                        padre.datos[i+1]=0;
                    }
                    switch (padre.tipo){
                        case 0:
                            break;
                        case 1:
                            if(padre.cantidad > 0){
                                if (numero != 0){
                                    padre.delante[numero-1]=padre.delante[numero];
                                    padre.delante[numero]=0;
                                    for (int i=numero; i < padre.cantidad; i++){
                                        padre.delante[i-1]=padre.delante[i];
                                        padre.atras[i]=0;
                                    }
                                }
                            }
                            break;
                        case 2:
                            if(padre.cantidad > 0){
                                if (numero != 9){
                                    padre.atras[numero]=padre.atras[numero+1];
                                    padre.atras[numero+1]=0;
                                    for (int i=numero; i < padre.cantidad-1; i++){
                                        padre.atras[i]=padre.atras[i+1];
                                        padre.atras[i+1]=0;
                                    }
                                }
                                if (numero != 0){
                                    padre.delante[numero-1]=padre.delante[numero];
                                    padre.delante[numero]=0;
                                    for (int i=numero; i < padre.cantidad; i++){
                                        padre.delante[i-1]=padre.delante[i];
                                        padre.atras[i]=0;
                                    }
                                }
                                
                            }
                            break;
                        case 3:
                            for (int i=0; i < padre.cantidad; i++){
                                if (padre.datos[i] != 0){
                                    padre.index[i]=i;
                                }else{
                                    padre.index[i]=0;
                                }
                            }
                            break;            
                    }
                    padre.cantidad--;
                }
                padre.Show();
                this.Hide();
            }
        };
        conV.PackStart(buttonI, false, false, 5);
        conV.PackStart(button, false, false, 5);
        Add(conV);
        ShowAll();
    }
}

public class Mostrar : Window //completar
{
    public Mostrar(Menu2 padre) : base("Mostrar Datos")
    {
        VBox conV = new VBox();
        SetDefaultSize(800, 200);
        Button button = new Button("Regresar");
        button.Clicked += (sender, e) =>
        {
            padre.Show();
            this.Hide();
        };
        string tipo = "";
        string listado = "";
        switch (padre.tipo){
            case 0:
                tipo = "Prueba de Lista Contigua";
                for(int i=0; i < padre.cantidad; i++){
                    listado += $"[{padre.datos[i]}]";
                    if(!(i==padre.cantidad-1)){
                        listado += ", \n";
                    }    
                }
                break;
            case 1:
                tipo = "Prueba de Lista Ligada";
                for(int i=0; i < padre.cantidad; i++){
                    listado += $"[{padre.datos[i]}]";
                    if(i<9 && padre.delante[i] != 0){
                        listado += $"->[{padre.delante[i]}]";
                    }else{
                        listado += $"->[]";
                    }
                    if(!(i==padre.cantidad-1)){
                        listado += ", \n";
                    }        
                }
                break;
            case 2:
                tipo = "Prueba de Lista Doble Ligada";
                for(int i=0; i < padre.cantidad; i++){
                    if (i==0){
                        listado += $"[]<-[{padre.datos[i]}]";  
                    }else{
                        listado += $"[{padre.atras[i]}]<-[{padre.datos[i]}]";  
                    }
                    if(i<9 && padre.delante[i] != 0){
                        listado += $"->[{padre.delante[i]}]";
                    }else{
                        listado += $"->[]";
                    }
                    if(!(i==padre.cantidad-1)){
                        listado += ", \n";
                    }              
                }
                break;
            case 3:
                tipo = "Prueba de Lista Index";
                for(int i=0; i < padre.cantidad; i++){
                    listado += $"[{padre.index[i]}] : [{padre.datos[i]}]";
                    if(!(i==padre.cantidad-1)){
                        listado += ", \n";
                    }              
                }
                break;            
        }
        conV.PackStart(new Label(tipo), false, false, 5);
        conV.PackStart(new Label(listado), false, false, 5);
        conV.PackStart(button, false, false, 5);
        Add(conV);
        ShowAll();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Application.Init();
        Window menu = new Menu1();
        menu.DeleteEvent += delegate { Application.Quit(); };
        menu.SetPosition(WindowPosition.CenterAlways);
        Application.Run();
    }
}
