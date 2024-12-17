package com.example.psychoapp.model.data.login

data class User22(
    val firstName: String,
    val lastName: String,
    val username: String,
    val email: String,
    val password: String
)

data class User(
    val email: String,
    val firstName: String,
    val lastLogin: String,
    val lastName: String,
    val passwordHash: String,
    val username: String,
    val createdDate: String
)


data class SignUpResponse(
    val status: String,
    val message: String,
    val date: TokenData?
)

data class TokenData(
    val token: String,
    val refreshToken: String
)