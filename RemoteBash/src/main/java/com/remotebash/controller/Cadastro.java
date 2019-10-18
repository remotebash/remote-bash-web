package com.remotebash.controller;

import javax.validation.Valid;

import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
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
	
	@PostMapping("/")
	public ModelAndView postDados(@Valid User user) {
		
	    RestTemplate restTemplate = new RestTemplate();
		String url = "localhost:8081/printar";
		
		HttpHeaders headers = new HttpHeaders();
		
		headers.add("nome", user.getName());
		headers.add("senha", user.getPassword());

		final MultiValueMap<String, String> bodyMap = new LinkedMultiValueMap<>();
		
	    bodyMap.add("email", user.getEmail());
	    bodyMap.add("endereco", user.getAddress());


	    HttpEntity<MultiValueMap<String, String>> requestEntity = new HttpEntity<>(bodyMap, headers);
	    String result = restTemplate.postForObject(url, requestEntity, String.class);
	    System.err.println(result);
		
		System.err.println(String.format("%s, %s, %s, %s, %s",
				user.getName(),
				user.getEmail(),
				user.getPassword(),
				user.getCellphone(),
				user.getAddress()
		));		
		
		
		return acessoCadastro();
		
	}
	
	
}
