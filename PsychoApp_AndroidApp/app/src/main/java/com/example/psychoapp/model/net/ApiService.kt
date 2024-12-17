package com.example.psychoapp.model.net

import com.example.psychoapp.model.data.login.SignUpResponse
import com.example.psychoapp.model.data.login.User
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.POST

interface ApiService {
    @POST("api/Users/register")
    suspend fun register(@Body user: User): Response<SignUpResponse>
}