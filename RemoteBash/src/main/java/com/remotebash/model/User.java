package com.remotebash.model;

import java.util.ArrayList;
import java.util.List;

public class User {

	private String name;
	private String password;
	private String cellphone;
	private String email;
	private String address;
	
	public User() {}
	
	public List<String> dadosUsuario(){
		
		List<String> usuario = new ArrayList<String>();
		
		usuario.add(getName());
		usuario.add(getEmail());
		usuario.add(getPassword());
		usuario.add(getCellphone());
		usuario.add(getAddress());
		
		return usuario;
	}
	
	public User(String name, String password, String cellphone, String email, String address) {
		this.name = name;
		this.password = password;
		this.cellphone = cellphone;
		this.email = email;
		this.address = address;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getCellphone() {
		return cellphone;
	}

	public void setCellphone(String cellphone) {
		this.cellphone = cellphone;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}
	
	
}
