import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApiService } from 'src/app/Services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-form-farmacos',
  templateUrl: './form-farmacos.component.html',
  styleUrls: ['./form-farmacos.component.css']
})
export class FormFarmacosComponent {
  form: FormGroup = new FormGroup({
    nombre: new FormControl('', [Validators.required]),
    precio: new FormControl('', [Validators.required]),
    stok: new FormControl('', [Validators.required]),
    idFarmacia: new FormControl('', [Validators.required]),
  });

  constructor(private api: ApiService) { }

  submit() {
    let validationMessage: string;
    console.log(this.form.value)
    if (this.form.valid) {
      validationMessage = 'La validación fue correcta';
      this.api.Post('Farmacoes', this.form.value).then(() => {
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
      'Success',
      'Validacion Correcta',
      'success'
    )
  }

  @Input() error: string | null;

  @Output() submitEM = new EventEmitter();
}
