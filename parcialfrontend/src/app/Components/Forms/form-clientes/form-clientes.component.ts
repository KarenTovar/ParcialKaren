import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApiService } from 'src/app/Services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-form-clientes',
  templateUrl: './form-clientes.component.html',
  styleUrls: ['./form-clientes.component.css']
})
export class FormClientesComponent {
  form: FormGroup = new FormGroup({
    nombre: new FormControl('', [Validators.required]),
    telefono: new FormControl('', [Validators.required]),
    direccion: new FormControl('', [Validators.required]),
    documento: new FormControl('', [Validators.required]),
  });

  constructor(private api: ApiService) { }

  submit() {
    let validationMessage: string;
    console.log(this.form.value)
    if (this.form.valid) {
      validationMessage = 'La validación fue correcta';
      this.api.Post('Clientes', this.form.value).then(() => {
        // Éxito en la llamada POST
        this.submitEM.emit();
      }, (error) => {
        // Error en la llamada POST
        this.error = error.message;
      });
    } else {
      validationMessage = 'Por favor, complete todos los campos';
    }

    validationMessage == "Validacion incorrecta" ? Swal.fire(
      'Error',
      'Validacion incorrecta',
      'error'
    ) : Swal.fire(
      'Succes',
      'Validacion Correcta',
      'success'
    )
  }

  @Input() error: string | null;

  @Output() submitEM = new EventEmitter();
}