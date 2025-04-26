import { RouterOutlet } from '@angular/router';
import { Component } from '@angular/core';
import { ClienteListComponent } from './clientes-list/clientes-list.component';
import { ClienteFormComponent } from './cliente-form/cliente-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ClienteListComponent, ClienteFormComponent],
  template: `
    <h1>Minha Loja 🛒</h1>
    <app-clientes-list></app-clientes-list>
    <app-cliente-form></app-cliente-form>
  `
})
export class AppComponent {}