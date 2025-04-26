import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { ClienteComponent } from '../clientes/clientes.component';
import { Cliente, ClienteService } from '../services/cliente.services';

@Component({
    selector: 'app-clientes-list',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './clientes-list.component.html',
    styleUrls: ['./clientes-list.component.css']
})

export class ClienteListComponent implements OnInit {
    private clienteService = inject(ClienteService)
    clientes: Cliente[] = [];

    ngOnInit(){
        this.clienteService.getClientes().subscribe((data) => {
            this.clientes = data;
        });
    }
}