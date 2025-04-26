import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Cliente {
  id?: string;
  nome: string;
  email: string;
  cpf: string;
  dataNascimento: string;
}

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private readonly apiUrl = 'https://localhost:7014/api/clientes';

  constructor(private http: HttpClient) {}

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.apiUrl);
  }

  criarCliente(cliente: Cliente): Observable<Cliente>{
    return this.http.post<Cliente>(this.apiUrl, cliente)
  }




}