import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/users.model';
import * as moment from 'moment';
import { UsersService } from 'src/app/services/users.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css'],
})
export class EditUserComponent implements OnInit {
  userDetails: User = {
    user_id: '',
    nama_user: '',
    nomor_hp: '',
    keterangan: '',
    maks_transaksi: 0,
    tanggal_masuk: moment().toDate(),
  };
  constructor(
    private usersService: UsersService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.usersService.doGetDetailUser(id)
          .subscribe({
            next: (response) => {
              this.userDetails = response;
              console.log(response)
            }
          });
        }
      },
    });
  }

  doUpdate(){
    this.usersService.doUpdate(this.userDetails.user_id, this.userDetails)
    .subscribe({
      next: (response) => {
        this.router.navigate(['users']);
      }
    });
  }

  doDelete(id: string){
    this.usersService.doDelete(id)
    .subscribe({
      next: (response) => {
        this.router.navigate(['users']);
      }
    })
  }
}
