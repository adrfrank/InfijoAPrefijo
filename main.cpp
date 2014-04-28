#include <iostream>
#include <stack>
#include <string>

using namespace std;

string InfijoPrefijo(string);
stack<char> PilaInfijoPrefijo(string);
int Jerarquia(char elemento);


int main()
{
    string infjo;
    cout << "Infijo a prefio" <<endl<< endl;
    cout<<"Ingresa la cadena: ";
    cin>>infjo;
    cout<<"La cadena en prefijo es: "<<InfijoPrefijo(infjo)<<endl;
    return 0;
}


string  InfijoPrefijo(string infijo){
    string prefijo = "";
    stack<char> pPrefijo = PilaInfijoPrefijo(infijo);
    while(!pPrefijo.empty()){
        prefijo += pPrefijo.top();
        pPrefijo.pop();
    }
    return prefijo;
}

stack<char> PilaInfijoPrefijo(string infijo){
    infijo = "(" + infijo ;
        int tam = infijo.size();
        stack<char> pInfija = stack<char>();
        stack<char> PilaTemp = stack<char>();
        PilaTemp.push(')'); // Agregamos a la pila temporal un '('
        for (int i = tam-1; i > -1; i--) {
            char caracter = infijo[i];
            switch (caracter) {
            case ')':
                PilaTemp.push(caracter);
                break;
            case '+':case '-':case '^':case '*':case '/':
                while (Jerarquia(caracter) > Jerarquia(PilaTemp.top())){
                    pInfija.push(PilaTemp.top());
                    PilaTemp.pop();
                }
                PilaTemp.push(caracter);
                break;
            case '(':
                while (PilaTemp.top() != ')'){
                    pInfija.push(PilaTemp.top());
                    PilaTemp.pop();
                }
                PilaTemp.pop();
                break;
            default:
                pInfija.push(caracter);
            }
        }
        return pInfija;

}

 int Jerarquia(char elemento) {
        int res = 0;
        switch (elemento) {
        case ')':
            res = 5; break;
        case '^':
            res = 2; break;
        case '*': case '/':
            res = 3; break;
        case '+': case '-':
            res = 4; break;

        }
        return res;
    }
