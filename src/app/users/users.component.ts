import { Component, OnInit } from '@angular/core';
import { User} from "../models/User";
import { UserService} from "../services/user.service";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  users:User[] = [];
  selectedUser? : User;

  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(users => {
      this.users = users;
    });
  }

  // when user is clicked --------------------------------
  onSelect(user: User): void {
    this.selectedUser = user;
  }
}
