package com.remotebash.controller;

import javax.validation.Valid;

import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.util.LinkedMultiValueMap;
import org.springframework.util.MultiValueMap;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.servlet.ModelAndView;

import com.remotebash.model.User;

@Controller
public class Cadastro {

	private ModelAndView modelAndView;
	private User user;
	
	@RequestMapping(value = { "/", "/remotebash" }, method = RequestMethod.GET)
	public ModelAndView acessoCadastro() {
		user = new User();
		modelAndView = new ModelAndView();
		
		modelAndView.addObject("user", user);
		modelAndView.setViewName("cadastro");
		return modelAndView;		
	}
	
	@PostMapping("/cadastrar")
	public ModelAndView postDados(@Valid User user) {
		
	    RestTemplate restTemplate = new RestTemplate();
		final String URL_REGISTER_USER = "http://3.94.151.158:8082/register/users";
		
		HttpHeaders headers = new HttpHeaders();
		headers.setContentType(MediaType.APPLICATION_JSON);
		
	    HttpEntity<User> requestEntity = new HttpEntity<>(user, headers);
	    String response = restTemplate.postForObject(URL_REGISTER_USER, requestEntity, String.class);	    
	    System.err.println(response);
		
		return acessoCadastro();
		
	}
	
	
}
