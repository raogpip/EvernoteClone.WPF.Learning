using EvernoteClone.WPF.Learning.Model;
using EvernoteClone.WPF.Learning.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.WPF.Learning.ViewModel
{
    public class LoginVM
    {
		private User user;

		public User User
		{
			get { return user; }
			set { user = value; }
		}

		public RegisterCommand RegisterCommand{ get; set; }

		public LoginCommand LoginCommand { get; set; }

		public LoginVM()
		{
			RegisterCommand = new RegisterCommand(this);
			LoginCommand = new LoginCommand(this);
		}
	}
}
