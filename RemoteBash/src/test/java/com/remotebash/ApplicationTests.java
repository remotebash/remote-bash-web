package com.remotebash;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import com.remotebash.controller.Cadastro;
import com.remotebash.model.User;

@RunWith(SpringRunner.class)
@SpringBootTest
public class ApplicationTests {

	@Test
	public void contextLoads() {
	}
	
	@Test
	public void postCadastroUser() {
		
		User user = new User("juvencio", "123", "0000-0000", "juvencio@.com", "Rua");
		Cadastro cadastro = new Cadastro();
		cadastro.postDados(user);		
		
	}

}
