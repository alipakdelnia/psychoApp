package com.example.psychoapp.model.repository

import com.example.psychoapp.model.data.login.SignUpResponse
import com.example.psychoapp.model.data.login.User
import com.example.psychoapp.model.net.ApiService
import javax.inject.Inject
import javax.inject.Singleton

@Singleton
class UserRepository @Inject constructor(private val apiService: ApiService) {
    suspend fun registerUser(user: User): SignUpResponse {
        val response = apiService.register(user)
        if (response.isSuccessful) {
            return response.body()!!
        } else {
            throw Exception("Error: ${response.code()}")
        }
    }
}