package com.example.psychoapp.ui.screens.Login

import android.util.Log
import android.widget.Toast
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.psychoapp.model.data.login.SignUpResponse
import com.example.psychoapp.model.data.login.User
import com.example.psychoapp.model.net.Resource
import com.example.psychoapp.model.repository.UserRepository
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch
import javax.inject.Inject
import kotlin.math.log

@HiltViewModel
class RegisterViewModel @Inject constructor(
    private val userRepository: UserRepository
) : ViewModel() {
    private val _response = MutableLiveData<SignUpResponse>()
    val response: LiveData<SignUpResponse> get() = _response

    fun registerUser(user: User) {
        var userRequest = User(
            firstName = user.firstName,
            lastName = user.lastName,
            username = user.username,
            email = user.email,
            passwordHash = user.passwordHash,
            lastLogin = user.lastLogin,
            createdDate = user.createdDate
        )
        viewModelScope.launch {
            try {

                val signUpResponse = userRepository.registerUser(userRequest)
                _response.value = signUpResponse

                Log.v("logloginresponse", signUpResponse.message.toString())


            } catch (e: Exception) {
//                _response.value = "   ثبت نام ناموفق!!!${e.message} "
                Log.v("logloginerror", e.message.toString())

            }
        }
    }
}
