import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ClienteService } from '../services/cliente.services';

@Component({
  selector: 'app-cliente-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent {
  private clienteService = inject(ClienteService);

  cliente = {
    nome: '',
    email: '',
    cpf: '',
    dataNascimento: ''
  };

  salvar() {
    this.clienteService.criarCliente(this.cliente).subscribe(() => {
      alert('Cliente criado com sucesso!');
      // Você pode limpar o formulário aqui também
    });
  }
}