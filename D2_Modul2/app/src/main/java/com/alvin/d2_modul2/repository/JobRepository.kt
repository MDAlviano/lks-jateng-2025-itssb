package com.alvin.d2_modul2.repository

import com.alvin.d2_modul2.http.HttpHandler

object JobRepository {

    fun applyJob(jobId: Int): String {
        return HttpHandler.postRequest(
            endpoint = "api/jobs/$jobId/apply"
        )
    }

}