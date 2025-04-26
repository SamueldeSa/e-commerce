import { bootstrapApplication } from '@angular/platform-browser';
import { ClienteListComponent } from './app/clientes-list/clientes-list.component';
import { ClienteFormComponent } from './app/cliente-form/cliente-form.component';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent, {
    providers: [provideHttpClient()]
});
